using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace ConsoleAppWebApiHost
{
    /*
     *由于我们自定义的AssembliesResolver是对现有DefaultAssembliesResolver的扩展
     * （尽管其程序集提供机制仅仅通过一句代码来实现），
     * 我们将类型命名为ExtendedDefaultAssembliesResolver。如下面的代码片断所示，
     * ExtendedDefaultAssembliesResolver继承自DefaultAssembliesResolver，
     * 在重写的GetAssemblies方法中我们先通过分析上述的配置并主动加载尚未加载的程序集，
     * 然后调用基类的同名方法来提供最终的程序集。
     * 资料地址：http://www.cnblogs.com/artech/archive/2014/04/10/custom-assembly-resolver.html
     */
    public class ExtendedDefaultAssembliesResolver:DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {

            PreLoadedAssembliesSettings setting = PreLoadedAssembliesSettings.GetSection();
            if (null != setting)
            {
                foreach (AssemblyElement item in setting.AssemblyNames)
                {
                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(item.AssemblyName);
                    //AssemblyName.m
                    if (!AppDomain.CurrentDomain.GetAssemblies()
                        .Any(assembly => AssemblyName.ReferenceMatchesDefinition(assembly.GetName()
                        , assemblyName)))


                    {

                        AppDomain.CurrentDomain.Load(assemblyName);
                    }

                }

            }
            return base.GetAssemblies();
        }
    }
}
