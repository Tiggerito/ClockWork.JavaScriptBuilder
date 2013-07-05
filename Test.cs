using System;
using System.Collections.Generic;
using System.Text;
using ClockWork.JavaScriptBuilder.JavaScript;

namespace ClockWork.JavaScriptBuilder
{
    class Test
    {

        public  Test()
        {
            ScriptDocument sd = new ScriptDocument();

			JsBuilder js = new JsBuilder(sd);

			sd.Content.AddRange(
				js.S(
                    "hghfgdgshf = ",
					js.F(
						js.L("sdfd", "dfdf"),
						js.SL(
                            "sfdgfg;",
                            "sfdgfg;",
                            "sfdgfg;",
                            "sfdgfg;",
                            "sfdgfg;"
                        )
                    )
                )
            );
        }
    }
}
