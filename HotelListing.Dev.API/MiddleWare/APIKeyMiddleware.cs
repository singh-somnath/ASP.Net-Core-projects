using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HotelListing.Dev.API.MiddleWare
{
    public class APIKeyMiddleware : IMiddleware
    {
        private const string AuthoriationHeaderTitle = "Authorization";
        private const string Thumbprint = "0fbdd19c1ca56b41936cd5e412b0ce28679ad8e7";

        private static X509Certificate2 GetCertiFicate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, Thumbprint, false);

            try
            {
               if(certCollection != null)
                    return certCollection[0];
            }
            catch
            {
                throw;
            }
            finally
            {
                if(store != null)
                    store.Close();
            }
            return null;          
          
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                var path = Convert.ToString(context.Request.Path);

                if (path.Contains("/api/"))
                {
                    if (!context.Request.Headers.TryGetValue(AuthoriationHeaderTitle, out var authValue))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized Request");
                        return;
                    }

                    X509Certificate2 certificate = APIKeyMiddleware.GetCertiFicate();
                    if (certificate != null)
                    {
                        var rsaPrivateKey = certificate.GetRSAPrivateKey();

                        String decryptMsg = Encoding.UTF8.GetString(rsaPrivateKey.Decrypt(Convert.FromBase64String(authValue), RSAEncryptionPadding.Pkcs1));

                        if (decryptMsg != "AXXPA0117ACLTPS4286A")
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Invalid API Key");
                            return;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized Request");
                        return;
                    }
                }
                else
                {
                    Console.Write("Outside Secure API\n");
                }
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"{ex.Message}");
                return;
            }


        }
    }
}
