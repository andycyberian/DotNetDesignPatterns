using ChainOfResponsibility.UserProcessing.Exceptions;
using ChainOfResponsibility.UserProcessing.Models;

namespace ChainOfResponsibility.UserProcessing.Handlers.UserValidation;

public class AgeValidationHandler : Handler<User>
{
    public override void Handle(User user)
    {
        if (user.Age < 18)
        {
            throw new UserValidationException("You have to be 18 years or older");
        }

        base.Handle(user);
    }
}