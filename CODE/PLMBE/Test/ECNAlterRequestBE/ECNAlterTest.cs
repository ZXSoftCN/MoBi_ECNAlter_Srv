
using System;
using System.Collections;
using System.Transactions;
using NUnit.Framework;
using UFSoft.UBF.Business;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.TestSuite{

	/// <summary>
	/// ECNAlter Auto Test Class
	/// </summary>
	[TestFixture]
	public partial class ECNAlterTest{
		/// <summary>
		/// test Create
		/// </summary>
		//[Test]
		public void ECNAlterCRUD() {
		/*	using (TransactionScope scope = new TransactionScope())
			{
				#region __merge CustomVariable
				UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo obj;
				//add you custome variable code here ...
				#endregion

				using (ISession session = Session.Open()) {
					#region __merge CreateECNAlter
					
					obj  = UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.Create() ;
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter n_ecnalter =UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.Create(obj) ;


					//add you custome assign code here ...
					#endregion

					Assert.IsNotNull(obj, " Create <" + typeof(ECNAlter).ToString() + "> failed.");
					session.Commit();
				}
	
				UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityList list = UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.Finder.FindAll("");
				Assert.IsTrue(list.Contains(obj), " Add <" + typeof(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo).ToString() + "> failed.");
				using (ISession session = Session.Open()) {
					#region __merge RemoveECNAlter	
					obj.Remove();
					//add you custom remove code here ...
					#endregion

					session.Commit();
				}
				list = UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.Finder.FindAll("");
				Assert.IsFalse(list.Contains(obj), " Delete <" + typeof(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo).ToString() + "> failed.");
			}
		*/
		}
	}
}

