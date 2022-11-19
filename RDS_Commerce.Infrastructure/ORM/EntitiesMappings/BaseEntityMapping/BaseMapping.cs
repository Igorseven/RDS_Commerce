namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings.BaseEntityMapping;
public abstract class BaseMapping
{
    protected string Schema { get; set; }
	private const string SCHEMA_DEFAULT = "RDS";

	public BaseMapping()
	{
		Schema = SCHEMA_DEFAULT;
    }

	public BaseMapping(string schema)
	{
		Schema = schema;
	}
}
