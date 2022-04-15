using System.Reflection;
using backend.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace backend.Extensions
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>();
        }
    }
}