namespace WebServer.Server.Http.Response
{
    using Enums;
    using Common;
    using System;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
