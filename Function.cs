using System.Net;
using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]


namespace BackendEngineeringCandidateTest
{
	
	
	
    public class Function
    {
        /// <summary>
        /// A simple hello function that always responds with Hello World
        /// </summary>
        public async Task<APIGatewayProxyResponse> SayHelloAsync(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return await Task.FromResult(new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello, world!"
				
				
            });
			
        }
    }
}
