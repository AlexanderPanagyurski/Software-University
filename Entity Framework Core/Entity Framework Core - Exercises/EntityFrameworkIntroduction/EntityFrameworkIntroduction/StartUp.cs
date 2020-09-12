using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(RemoveTown(db));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.OrderBy(e => e.EmployeeId).Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                MiddleName = e.MiddleName,
                JobTitle = e.JobTitle,
                Salary = decimal.Parse($"{e.Salary:f2}")
            }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append($"{e.FirstName} - {e.Salary:f2}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context
                .Employees
                .First(e => e.LastName == "Nakov");

            context.Addresses.Add(newAddress);
            employee.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    Address = e.Address.AddressText
                })
                .ToArray();

            foreach (var a in addresses)
            {
                sb.Append(a.Address + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
               .Employees
               .Where(e => e.EmployeesProjects
               .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
               .Take(10)
               .Select(e => new
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                   Projects = e.EmployeesProjects.Select(ep => new
                   {
                       ProjectName = ep.Project.Name,
                       ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                       ProjectEndDate = ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                   })
                   .ToArray()
               })
               .ToArray();
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append($"{e.FirstName} {e.LastName} - Manager: {e.Manager}" + Environment.NewLine);
                foreach (var p in e.Projects)
                {
                    sb.Append($"--{p.ProjectName} - {p.ProjectStartDate} - {p.ProjectEndDate}" + Environment.NewLine);
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.Append($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .First(e => e.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();
            sb.Append($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}" + Environment.NewLine);

            foreach (var e in employee.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.Append(e.Project.Name + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d
                    .Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle,
                    })
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.Append($"{d.DepartmentName} - {d.Manager}" + Environment.NewLine);

                foreach (var e in d.Employees)
                {
                    sb.Append($"{e.FirstName} {e.LastName} - {e.JobTitle}" + Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.Append($"{p.Name}" + Environment.NewLine);
                sb.Append($"{p.Description}" + Environment.NewLine);
                sb.Append($"{p.StartDate}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
          .Where(e => e.Department.Name == "Engineering" ||
          e.Department.Name == "Tool Design" ||
          e.Department.Name == "Marketing" ||
          e.Department.Name == "Information Services")
          .ToList();

            List<Employee> updatedEmployees = new List<Employee>();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                context.SaveChanges();
                updatedEmployees.Add(employee);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var employee in updatedEmployees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.ToLower().StartsWith("SA"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.Append($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var targetProject = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            var targetEmployeeProject = context.EmployeesProjects.FirstOrDefault(ep => ep.ProjectId == 2);

            context.EmployeesProjects.Remove(targetEmployeeProject);
            context.Projects.Remove(targetProject);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town town = context.Towns.First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete = context
                .Addresses
                .Where(a => a.TownId == town.TownId);

            int count = addressesToDelete.Count();

            IQueryable<Employee> employees = context
                .Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();


            return $"{count} addresses in Seattle were deleted";
        }
    }
}
