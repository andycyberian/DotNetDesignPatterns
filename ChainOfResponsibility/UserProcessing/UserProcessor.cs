using ChainOfResponsibility.UserProcessing.Exceptions;
using ChainOfResponsibility.UserProcessing.Handlers.UserValidation;
using ChainOfResponsibility.UserProcessing.Models;

namespace ChainOfResponsibility.UserProcessing;

public class UserProcessor
{
    public bool Register(User user)
    {
        try
        {
            var handler = new SocialSecurityNumberValidatorHandler();

            handler.SetNext(new AgeValidationHandler())
                .SetNext(new NameValidationHandler())
                .SetNext(new CitizenshipRegionValidationHandler());

            handler.Handle(user);
        }
        catch (UserValidationException ex)
        {
            return false;
        }
        catch (UnsupportedSocialSecurityNumberException ex)
        {
            return false;
        }

        return true;
    }
}
