using LnW.DotNet.PmsApp.BusinessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;
using static LnW.DotNet.PmsApp.UserInterface.Utility.UIStrings;

namespace LnW.DotNet.PmsApp.UserInterface.Utility
{
    public class UiManager(IPmsBo<Product, string> _pmsBo, ILogger<UiManager> _logger)
    {
        private static string? GetId()
        {
            string? id = null;
            try
            {
                Console.Write("enter id to get product details: ");
                id = Console.ReadLine();
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return id;
        }

        private static string GenerateMessage(string nameOfProp, Product? existing = null)
        {
            if (existing != null)
                return $"Old {nameOfProp}:{existing.Name}\nEnter new {nameOfProp}: ";
            else
                return $"\nEnter {nameOfProp}: ";
        }

        private static Product CreateProduct(Product? existing = null)
        {
            try
            {
                Console.Write(GenerateMessage("Name", existing));
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write(GenerateMessage("Price", existing));
                decimal price = decimal.Parse(Console.ReadLine() ?? "0");

                Console.Write(GenerateMessage("Description", existing));
                string? description = Console.ReadLine();

                Console.Write(GenerateMessage("Make", existing));
                string? make = Console.ReadLine() ?? string.Empty;

                Console.Write(GenerateMessage("Year", existing));
                int year = int.Parse(Console.ReadLine() ?? DateTime.Now.Year.ToString());

                return new Product { Id = string.Empty, Make = make, Price = price, Description = description, Name = name, Year = year };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ShowAllProducts(int? choice = null)
        {
            try
            {
                IEnumerable<Product>? allProducts;
                if (choice == null)
                    allProducts = _pmsBo.FetchAll();
                else
                {
                    SortChoice sortChoice = choice switch
                    {
                        1 => SortChoice.SortById,
                        2 => SortChoice.SortByName,
                        3 => SortChoice.SortByPrice,
                        4 => SortChoice.SortByMake,
                        5 => SortChoice.SortByYear,
                        _ => SortChoice.SortById
                    };
                    allProducts = _pmsBo.FetchAll(sortChoice);
                }
                if (allProducts != null)
                    foreach (var item in allProducts)
                    {
                        Console.WriteLine(item);
                    }
                else
                    Console.WriteLine("no product record");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        private void ShowProduct()
        {
            try
            {
                string? id = GetId();
                if (id != null)
                {
                    var found = _pmsBo.Fetch(id);
                    Console.WriteLine(found?.ToString());
                }
                else
                    throw new NullReferenceException($"{nameof(id)} is null");
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex.ToString());
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        private void UpdateExistingProduct()
        {
            try
            {
                string? id = GetId();
                if (id != null)
                {
                    var found = _pmsBo.Fetch(id);
                    var productToUpdate = CreateProduct(found);
                    var result = _pmsBo.Modify(id, productToUpdate);
                    Console.WriteLine(result ? UPDATE_SUCCESS_MESSAGE : UPDATE_FAILED_MESSAGE);
                }
                else
                    throw new NullReferenceException($"{nameof(id)} is null");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        private void AddNewProduct()
        {
            try
            {
                var productToAdd = CreateProduct();
                var result = _pmsBo.Add(productToAdd);
                Console.WriteLine(result ? ADD_SUCCESS_MESSAGE : ADD_FAILED_MESSAGE);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        private void DeleteExistingProduct()
        {
            try
            {
                string? id = GetId();
                if (id != null)
                {
                    var result = _pmsBo.Remove(id);
                    Console.WriteLine(result ? DELETE_SUCCESS_MESSAGE : DELETE_FAILED_MESSAGE);
                }
                else
                    throw new NullReferenceException($"{nameof(id)} is null");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        private void ShowMenu()
        {
            try
            {
                StringBuilder builder = new();
                builder.AppendLine($"1. Show All {nameof(Product)}s");
                builder.AppendLine($"2. Show A {nameof(Product)}");
                builder.AppendLine($"3. Add New Product Record");
                builder.AppendLine($"4. Update Existing {nameof(Product)} Record");
                builder.AppendLine($"5. Delete Existing {nameof(Product)} Record");
                builder.AppendLine("6. Exit");

                Console.WriteLine(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int GetChoice()
        {
            try
            {
                Console.Write("\nEnter Choice[1/2/3/4/5/6]: ");
                return int.Parse(Console.ReadLine() ?? "1");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void DecideToContinue(ref char decision)
        {
            try
            {
                Console.Write("Press any key to continue, except n/N to discontinue: ");
                decision = char.Parse(Console.ReadLine() ?? "n");
                decision = char.IsUpper(decision) ? char.ToLower(decision) : decision;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RunApp()
        {
            char toContinue = 'n';
            do
            {
                ShowMenu();
                var choice = GetChoice();
                switch (choice)
                {
                    case 1:
                        ShowAllProducts();
                        break;

                    case 2:
                        ShowProduct();
                        break;

                    case 3:
                        AddNewProduct();
                        break;

                    case 4:
                        ShowAllProducts();
                        UpdateExistingProduct();
                        break;

                    case 5:
                        ShowAllProducts();
                        DeleteExistingProduct();
                        break;

                    case 6:
                        Process.GetCurrentProcess().Kill();
                        break;

                    default:
                        Console.WriteLine("enter proper choice...");
                        break;
                }
                DecideToContinue(ref toContinue);
            } while (toContinue != 'n');
        }
    }
}
