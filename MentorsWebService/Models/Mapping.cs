namespace MentorsWebService.Models
{
    public static class Mapping<TOut,TInput>
        where  TInput : new()
        where  TOut : new()
    
    {
        public static TOut MappingUser(TInput inputData)
        {
            TOut newData = new TOut();

            if (newData is Teacher teacher && inputData is ViewTeacher tDataView)
            {
                teacher.UserName = tDataView.Username;
                teacher.NormalizedEmail = tDataView.Email;
                teacher.Bio = tDataView.Bio;
                
                return newData;
            }

            if (newData is Client client && inputData is ViewClient cDataView)
            {
                client.UserName = cDataView.Username;
                client.NormalizedEmail = cDataView.Email;
                return newData;
            }
            return default;
        }
    }
}