﻿

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using NUnit.Framework;
	
	/// <summary>
	/// Business operation test
	/// </summary> 
	[TestFixture]		
	public class ECNWHQueryTest
	{
		private Proxy.ECNWHQueryProxy obj = new Proxy.ECNWHQueryProxy();

		public ECNWHQueryTest()
		{
		}
		#region AutoTestCode ...
		[Test]
		public void TestDo()
		{
			obj.Do() ;  
		
		}
		#endregion 				
	}
	
}