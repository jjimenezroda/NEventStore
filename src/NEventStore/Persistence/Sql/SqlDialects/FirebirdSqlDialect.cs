namespace NEventStore.Persistence.Sql.SqlDialects
{
	public class FirebirdSqlDialect : CommonSqlDialect
	{
		public override string InitializeStorage
		{
			get { return FirebirdSqlStatements.InitializeStorage; }
		}

		public override string MarkCommitAsDispatched
		{
			get { return base.MarkCommitAsDispatched.Replace("1", "true"); }
		}

		public override string PersistCommit
		{
			get { return FirebirdSqlStatements.PersistCommits; }
		}

		public override string GetUndispatchedCommits
		{
			get { return base.GetUndispatchedCommits.Replace("0", "false"); }
		}
	}
}