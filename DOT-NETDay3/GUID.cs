
namespace DOT_NETDay3
{
    public interface IGUID1
    {
        Guid Getguid1();
    }
    public interface IGUID2
    {
        Guid Getguid1();
    }
    public interface IGUID3
    {
        Guid Getguid1();
    }

    public class GUID : IGUID1, IGUID2, IGUID3
    {
        private Guid _guid1;
        public GUID()
        {
            _guid1 = Guid.NewGuid();
        }
        public Guid Getguid1()
        {
            return _guid1;
        }


    }

}
