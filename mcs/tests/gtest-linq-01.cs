// Compiler options: -langversion:linq

using System;
using System.Collections.Generic;
using System.Linq;

namespace from
{
	interface ITest
	{
		int Id { get; }
	}

	class C
	{
		// This is pure grammar test
		public static void Main ()
		{
			int[] i2 = new int [] { 0, 1 };
			int[] i_b = new int [] { 0, 1 };
			ITest[] join_test = null;
			
			IEnumerable<int> e;
			IEnumerable<IGrouping<int,int>> g;

			// FROM
			e = from i in i2 select i;
			e = from int i in i2 select i;
			e = from i in new int[0] select i;
			e = from x in i2 from y in i2 select y;

			// WHERE
			e = from i in i2 where i % 3 != 0 select i;

			// ORDER BY
			e = from i in i2 orderby i select i;
			e = from i in i2 orderby i, i, i, i select i;
			e = from i in i2 orderby i descending select i;
			e = from i in i2 orderby i ascending select i;
			
			// JOIN
			e = from i in i2 join j in join_test on i equals j.Id select i;
			e = from i in i2 join ITest j in join_test on i equals j.Id select i;
			e = from i in i2 join j in join_test on i equals j.Id
				join j2 in join_test on i equals j2.Id select i;
			e = from i in i2 join j in i_b on i equals j into j select i;
			e = from i in i2 join int j in i_b on i equals j into j select i;

			// GROUP BY
			g = from i in i2 group i by 2;
			g = from i in i2 group i by 2 into i select i;

			// LET
			e = from i in i2 let l = i + 4 select i;
			e = from i in i2 let l = i + 4 let l2 = l + 2 select i;

			int from = 0;
			bool let = false;
			
			//object o = (object)from i in i2 select i;
		}
	}
}