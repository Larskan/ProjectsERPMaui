

using CommunityToolkit.Mvvm.Messaging.Messages;
using ProjectsERPMaui.Model;

namespace ProjectsERPMaui.Messages
{
    public class SendEmployeeInfo : ValueChangedMessage<Employee>
    {
        public SendEmployeeInfo(Employee value) : base(value)
        {

        }
    }
}
