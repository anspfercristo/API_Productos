namespace BusinessLogic.Commons
{
    /// <summary>
    /// Clase base para las implementaciones de handlers request/response.
    /// </summary>
    /// <typeparam name="TRequest">El tipo del request manejado.</typeparam>
    /// <typeparam name="TResponse">El tipo de response generado.</typeparam>
    public abstract class RequestResponseHandler<TRequest, TResponse>
    {

        public RequestResponseHandler()
        {
        }

        internal TResponse Execute(TRequest request)
        {
            TResponse response = default(TResponse);
            try
            {
                response = Handle(request);
            }
            catch (Exception)
            {
                var mguid = Guid.NewGuid();
                throw new Exception("Error del sistema, contacte al administrador. GUID:" + mguid.ToString());
            }

            return response;
        }

        public abstract TResponse Handle(TRequest request);
    }
}
