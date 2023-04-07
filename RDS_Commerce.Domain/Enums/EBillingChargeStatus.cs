using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum EBillingChargeStatus : ushort
{

    [Description("PENDING")]//Aguardando pagamento
    PENDING = 1,

    [Description("RECEIVED")]//Recebida (saldo já creditado na conta)
    RECEIVED,

    [Description("CONFIRMED")]//Pagamento confirmado (saldo ainda não creditado)
    CONFIRMED,

    [Description("OVERDUE")]//Vencida
    OVERDUE,

    [Description("REFUNDED")]//Estornada
    REFUNDED,

    [Description("RECEIVED_IN_CASH")]//Recebida em dinheiro (não gera saldo na conta)
    RECEIVED_IN_CASH,

    [Description("REFUND_REQUESTED")]//Estorno Solicitado
    REFUND_REQUESTED,

    [Description("CHARGEBACK_REQUESTED")] //Recebido chargeback
    CHARGEBACK_REQUESTED,

    [Description("CHARGEBACK_DISPUTE")]//Em disputa de chargeback (caso sejam apresentados documentos para contestação)
    CHARGEBACK_DISPUTE,

    [Description("AWAITING_CHARGEBACK_REVERSAL")]//Disputa vencida, aguardando repasse da adquirente
    AWAITING_CHARGEBACK_REVERSAL,

    [Description("DUNNING_REQUESTED")]//Em processo de negativação
    DUNNING_REQUESTED,

    [Description("DUNNING_RECEIVED")]//Recuperada
    DUNNING_RECEIVED,

    [Description("AWAITING_RISK_ANALYSIS")] //Pagamento em análise
    AWAITING_RISK_ANALYSIS
}
