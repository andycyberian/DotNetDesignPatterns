using ChainOfResponsibility.UserProcessing.Exceptions;
using ChainOfResponsibility.UserProcessing.Models;

namespace ChainOfResponsibility.UserProcessing.Handlers.UserValidation;

public class NameValidationHandler : Handler<User>
{
    public override void Handle(User user)
    {
        if (user.Name.Length <= 1)
        {
            throw new UserValidationException("Your name is unlikely this short.");
        }

        base.Handle(user);
    }
}
