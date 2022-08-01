using MentorsWebService.Models;

namespace MentorsWebService.Infrastructure
{
    public static class Mapping<TOut,TInput>
        where  TInput : new()
        where  TOut : new()
    
    {
        public static TOut MappingUser(TInput inputData)
        {
            TOut newData = new TOut();

            if (inputData is ViewRegisterUser userDataView)
            {
                if (newData is Teacher teacher)
                {
                    teacher.UserName = userDataView.Username;
                    teacher.NormalizedEmail = userDataView.Email;
                    teacher.Bio = userDataView.Bio;
                
                    return newData;
                }
                
                if (newData is Client client)
                {
                    client.UserName = userDataView.Username;
                    client.NormalizedEmail = userDataView.Email;
                    
                    return newData;
                }
            }
            return default;
        }
    }
}