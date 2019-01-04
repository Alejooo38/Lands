namespace Lands.Models
{
    /* Esta clase solo tiene tres atributos en la propiedad Result 
     * trae el resultado de la consulta. */

    public class Response
    {
        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }
    }
}