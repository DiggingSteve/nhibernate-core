﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2341
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override void OnTearDown()
		{
			using (var s = OpenSession())
			using (var tx = s.BeginTransaction())
			{
				s.Delete("from System.Object");
				tx.Commit();
			}
		}

		[Test]
		public async Task WhenSaveInstanceOfConcreteInheritedThenNotThrowsAsync()
		{
			using (var session = OpenSession())
			using (var tx = session.BeginTransaction())
			{
				var entity = new ConcreteB();
				Assert.That(() => session.SaveAsync(entity), Throws.Nothing);
				await (tx.CommitAsync());
			}
		}
	}
}
