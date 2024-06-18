namespace ApiFacultad.Resultados
{
    public class ResultadoBase
    {
        public bool Ok { get; set; } = true;

        public string Err { get; set; } = string.Empty;

        public string StatusCode { get; set; } = string.Empty;

        public void SetError(string mensajeError)
        {
            Ok = false;
            Err = mensajeError;

        }


    }
}
