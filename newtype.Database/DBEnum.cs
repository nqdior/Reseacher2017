namespace newtype.Database
{

    public enum GetData
    {
        Success = 0,
        Nothing = 1,
        Fail = 2,
    }


    public static class GetDataExt
    {

        public static bool IsAccess(this GetData isGet)
        {
            bool[] value = { true, true, false };
            return value[(int)isGet];
        }


        public static bool IsDataExist(this GetData isGet)
        {
            bool[] value = { true, false, false };
            return value[(int)isGet];
        }

    }
}
