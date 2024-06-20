using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public abstract class DisciplinaHandler : Handler
    {
        public Handler next;
        public override double handle(Performance performance)
        {
            if (next != null)
            {
                return next.handle(performance);
            }
            return -1.0;
        }

        public override void setNext(Handler handler)
        {
            this.next = handler;
        }
    }
}