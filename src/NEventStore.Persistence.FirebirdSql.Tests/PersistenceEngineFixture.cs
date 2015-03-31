namespace NEventStore.Persistence.AcceptanceTests
{
	using System;

	using NEventStore.Persistence.Sql;
	using NEventStore.Persistence.Sql.SqlDialects;
	using NEventStore.Serialization;

	public partial class PersistenceEngineFixture
	{
		private const string EnvVariable = "NEventStore.FirebirdSql";

		public PersistenceEngineFixture()
		{
			_createPersistence = pageSize =>
				new SqlPersistenceFactory(
					new EnviromentConnectionFactory("FirebirdSql", "FirebirdSql"),
					new BinarySerializer(),
					new FirebirdSqlDialect(),
					pageSize: pageSize).Build();
		}

		partial void SetEnvironmentVariable()
		{
			Environment.SetEnvironmentVariable(EnvVariable, "User=SYSDBA;Password=doesntmatter;Database=neventstore.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=UTF8;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=1;", EnvironmentVariableTarget.User);
		}

		partial void ClearEnvironmentVariable()
		{
			Environment.SetEnvironmentVariable(EnvVariable, null, EnvironmentVariableTarget.User);
		}
	}
}