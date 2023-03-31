

using CommunityToolkit.Mvvm.Messaging.Messages;
using ProjectsERPMaui.Model;

namespace ProjectsERPMaui.Messages
{
    public class SendEmployeeInfo : ValueChangedMessage<Employee>
    {
        /// <summary>
        /// Constructor that takes Employee object and calls constructor of base class(ValueChangedMessage)
        /// </summary>
        /// <param name="value"></param>
        public SendEmployeeInfo(Employee value) : base(value)
        {

        }
    }
}
