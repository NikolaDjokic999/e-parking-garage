namespace e_parking_garage.Core
{
    public abstract class CoreObject
    {
        private static long _currentId = 0;

        public long Id { get; set; }

        protected CoreObject()
        {
            Id = ++_currentId;
        }
    }
}
