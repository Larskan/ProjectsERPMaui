

using CommunityToolkit.Mvvm.Messaging.Messages;
using ProjectsERPMaui.Model;

namespace ProjectsERPMaui.Messages
{
    public class SendEmployeeInfo : ValueChangedMessage<Employee>
    {
        //Constructor that takes Employee object and calls constructor of base class(ValueChangedMessage)
        public SendEmployeeInfo(Employee value) : base(value)
        {

        }
    }
}
