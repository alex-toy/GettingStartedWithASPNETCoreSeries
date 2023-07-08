namespace MiddlewareWebApi
{
    public class Counter
    {
        private int count = 1;
        public int Count
        {
            get { return count++; }
        }
    }
}
