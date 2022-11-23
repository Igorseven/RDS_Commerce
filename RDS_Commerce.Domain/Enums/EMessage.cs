using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum EMessage
{
    [Description("{0} obrigatório.")]
    Required,

    [Description("Campo {0} permite {1} caracteres.")]
    MoreExpected,

    [Description("{0} não encontrado.")]
    NotFound,

    [Description("Não há registro na base dados do sistema.")]
    EmptyList,

    [Description("Selecione uma opção")]
    SelectAnOption,

    [Description("{0} já existe na base de dados.")]
    Exist,

    [Description("{0} deve ser maior que {1}.")]
    ValueExpected,

    [Description("Objeto não configurado")]
    ErrorNotConfigured,
}
