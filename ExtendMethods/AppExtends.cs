using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Controller_View.ExtendMethods
{
    public static class AppExtend
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
{
    appError.Run(async (context) =>
    {
        var response = context.Response;
        var code = response.StatusCode;
        var content = @$"
                        <html>
                            <head>
                                <meta charset ='UTF-8' />
                                <title>lỗi {code}</title>
                            </head>
                            <body>
                                <h4>Có lỗi xảy ra: {code} - {(HttpStatusCode)code}</h4>
                            </body>
                        </html>
                    ";
        await response.WriteAsync(content);
    });
}); // 400 - 599 -> tạo response body

        }

    }
}