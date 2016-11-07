using System.Collections.Generic;

namespace Api.Domain
{
    public interface FindUserQuery
    {
        User Execute(string userName);
    }
}
