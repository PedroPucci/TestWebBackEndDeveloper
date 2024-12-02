using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TestWebBackEndDeveloper.Extensions.SwaggerDocumentation
{
    public class CustomOperationDescriptions : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context?.ApiDescription?.HttpMethod == null || context.ApiDescription.RelativePath == null)
                return;

            var routeHandlers = new Dictionary<string, Action>
                {
                    { "account", () => HandleAccountUserOperations(operation, context) },
                    { "balance", () => HandleBalanceOperations(operation, context) },
                    { "deposit", () => HandleDepositOperations(operation, context) },
                    { "purchase", () => HandlePurchaseOperations(operation, context) },
                    { "quotation", () => HandleQuotationOperations(operation, context) }
                };

            foreach (var routeHandler in routeHandlers)
            {
                if (context.ApiDescription.RelativePath.Contains(routeHandler.Key))
                {
                    routeHandler.Value.Invoke();
                    break;
                }
            }
        }

        private void HandleAccountUserOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "POST")
            {
                operation.Summary = "Create a new account user";
                operation.Description = "This endpoint allows you to create a new account by providing the necessary details.";
                AddResponses(operation, "200", "The account user was successfully created.");
            }
            else if (context.ApiDescription.HttpMethod == "PUT")
            {
                operation.Summary = "Update an existing account user";
                operation.Description = "This endpoint allows you to update an existing account user by providing the necessary details.";
                AddResponses(operation, "200", "The account user was successfully updated.");
            }
            else if (context.ApiDescription.HttpMethod == "DELETE")
            {
                operation.Summary = "Delete an existing account user";
                operation.Description = "This endpoint allows you to delete an existing account user by providing the account ID.";
                AddResponses(operation, "200", "The account user was successfully deleted.");
                AddResponses(operation, "404", "Account user not found. Please verify the account ID.");
            }
            else if (context.ApiDescription.HttpMethod == "GET" &&
                    context.ApiDescription.RelativePath != null &&
                    context.ApiDescription.RelativePath.Contains("All"))
            {
                operation.Summary = "Retrieve all account users";
                operation.Description = "This endpoint allows you to retrieve details of all existing account users.";
                AddResponses(operation, "200", "All account user details were successfully retrieved.");
            }
            else if (context.ApiDescription.HttpMethod == "GET" &&
                     context.ApiDescription.RelativePath?.Contains("Balance for accountUser") == true)
            {
                operation.Summary = "Retrieve balance for an account user";
                operation.Description = "This endpoint allows you to retrieve the balance of an account user by providing the account ID.";
                AddResponses(operation, "200", "The account user's balance was successfully retrieved.");
            }
        }

        private void HandleBalanceOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            // TODO: Implement logic for balance operations.
        }

        private void HandleDepositOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "POST")
            {
                operation.Summary = "Create a new deposit";
                operation.Description = "This endpoint allows you to create a new deposit for an account user.";
                AddResponses(operation, "200", "The deposit was successfully created.");
                AddResponses(operation, "400", "Invalid request. Please check the provided data.");
            }
        }

        private void HandlePurchaseOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "POST")
            {
                operation.Summary = "Buy Bitcoin";
                operation.Description = "This endpoint allows you to make a Bitcoin purchase by providing the necessary details.";
                AddResponses(operation, "200", "The Bitcoin purchase was successfully processed.");
                AddResponses(operation, "400", "Invalid request. Please check the provided data.");
            }
        }

        private void HandleQuotationOperations(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "POST")
            {
                operation.Summary = "Create a new quotation";
                operation.Description = "This endpoint allows you to create a new quotation for Bitcoin.";
                AddResponses(operation, "200", "The quotation was successfully created.");
            }
            else if (context.ApiDescription.HttpMethod == "GET" &&
                     context.ApiDescription.RelativePath?.Contains("All QuotationsBuy") == true)
            {
                operation.Summary = "Retrieve all buy quotations";
                operation.Description = "This endpoint allows you to retrieve all buy quotations for Bitcoin.";
                AddResponses(operation, "200", "All buy quotations were successfully retrieved.");
            }
            else if (context.ApiDescription.HttpMethod == "GET" &&
                     context.ApiDescription.RelativePath?.Contains("All QuotationsSell") == true)
            {
                operation.Summary = "Retrieve all sell quotations";
                operation.Description = "This endpoint allows you to retrieve all sell quotations for Bitcoin.";
                AddResponses(operation, "200", "All sell quotations were successfully retrieved.");
            }
            else if (context.ApiDescription.HttpMethod == "GET" &&
                     context.ApiDescription.RelativePath?.Contains("All") == true)
            {
                operation.Summary = "Retrieve all quotations";
                operation.Description = "This endpoint allows you to retrieve all quotations for Bitcoin.";
                AddResponses(operation, "200", "All quotations were successfully retrieved.");
            }
        }

        private void AddResponses(OpenApiOperation operation, string statusCode, string description)
        {
            if (!operation.Responses.ContainsKey(statusCode))
            {
                operation.Responses.Add(statusCode, new OpenApiResponse { Description = description });
            }
        }
    }
}