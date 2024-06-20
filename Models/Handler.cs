namespace MySolidWebApi.Models
{

    public abstract class Handler
    {
        public abstract void setNext(Handler handler);
        public abstract double handle(Performance performance);
        
    }
}