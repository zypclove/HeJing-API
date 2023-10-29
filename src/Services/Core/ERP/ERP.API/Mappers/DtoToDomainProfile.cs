using ERP.Shared.DTO.BusinessEnterprise;
using ERP.Shared.DTO.BusinessEnterpriseCategory;
using ERP.Shared.DTO.Contract;
using ERP.Shared.DTO.ContractItem;
using ERP.Shared.DTO.Goods;
using ERP.Shared.DTO.GoodsCategory;
using ERP.Shared.DTO.PurchaseRequest;
using ERP.Shared.DTO.PurchaseRequestItem;
using ERP.Shared.DTO.ReturnGoods;
using ERP.Shared.DTO.ReturnGoodsItem;
using ERP.Shared.DTO.Stock;
using ERP.Shared.DTO.StockItem;

namespace ERP.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region BusinessEnterprise
        CreateMap<BusinessEnterpriseCreateInDto, BusinessEnterprise>();
        CreateMap<BusinessEnterpriseUpdateInDto, BusinessEnterprise>();
        CreateMap<BusinessEnterprise, BusinessEnterpriseQueryOutDto>();
        CreateMap<BusinessEnterprise, BusinessEnterpriseGetOutDto>();
        #endregion

        #region BusinessEnterpriseCategory
        CreateMap<BusinessEnterpriseCategoryCreateInDto, BusinessEnterpriseCategory>();
        CreateMap<BusinessEnterpriseCategoryUpdateInDto, BusinessEnterpriseCategory>();
        CreateMap<BusinessEnterpriseCategory, BusinessEnterpriseCategoryQueryOutDto>();
        CreateMap<BusinessEnterpriseCategory, BusinessEnterpriseCategoryGetOutDto>();
        #endregion

        #region Contract
        CreateMap<ContractCreateInDto, Contract>();
        CreateMap<ContractUpdateInDto, Contract>();
        CreateMap<Contract, ContractQueryOutDto>();
        CreateMap<Contract, ContractGetOutDto>();
        #endregion

        #region ContractItem
        CreateMap<ContractItemCreateInDto, ContractItem>();
        CreateMap<ContractItemUpdateInDto, ContractItem>();
        CreateMap<ContractItem, ContractItemQueryOutDto>();
        CreateMap<ContractItem, ContractItemGetOutDto>();
        #endregion

        #region Goods
        CreateMap<GoodsCreateInDto, Goods>();
        CreateMap<GoodsUpdateInDto, Goods>();
        CreateMap<Goods, GoodsQueryOutDto>();
        CreateMap<Goods, GoodsGetOutDto>();
        #endregion

        #region GoodsCategory
        CreateMap<GoodsCategoryCreateInDto, GoodsCategory>();
        CreateMap<GoodsCategoryUpdateInDto, GoodsCategory>();
        CreateMap<GoodsCategory, GoodsCategoryQueryOutDto>();
        CreateMap<GoodsCategory, GoodsCategoryGetOutDto>();
        #endregion

        #region PurchaseRequest
        CreateMap<PurchaseRequestCreateInDto, PurchaseRequest>();
        CreateMap<PurchaseRequestUpdateInDto, PurchaseRequest>();
        CreateMap<PurchaseRequest, PurchaseRequestQueryOutDto>();
        CreateMap<PurchaseRequest, PurchaseRequestGetOutDto>();
        #endregion

        #region PurchaseRequestItem
        CreateMap<PurchaseRequestItemCreateInDto, PurchaseRequestItem>();
        CreateMap<PurchaseRequestItemUpdateInDto, PurchaseRequestItem>();
        CreateMap<PurchaseRequestItem, PurchaseRequestItemQueryOutDto>();
        CreateMap<PurchaseRequestItem, PurchaseRequestItemGetOutDto>();
        #endregion

        #region ReturnGoods
        CreateMap<ReturnGoodsCreateInDto, ReturnGoods>();
        CreateMap<ReturnGoodsUpdateInDto, ReturnGoods>();
        CreateMap<ReturnGoods, ReturnGoodsQueryOutDto>();
        CreateMap<ReturnGoods, ReturnGoodsGetOutDto>();
        #endregion

        #region ReturnGoodsItem
        CreateMap<ReturnGoodsItemCreateInDto, ReturnGoodsItem>();
        CreateMap<ReturnGoodsItemUpdateInDto, ReturnGoodsItem>();
        CreateMap<ReturnGoodsItem, ReturnGoodsItemQueryOutDto>();
        CreateMap<ReturnGoodsItem, ReturnGoodsItemGetOutDto>();
        #endregion

        #region Stock
        CreateMap<StockCreateInDto, Stock>();
        CreateMap<StockUpdateInDto, Stock>();
        CreateMap<Stock, StockQueryOutDto>();
        CreateMap<Stock, StockGetOutDto>();
        #endregion

        #region StockItem
        CreateMap<StockItemCreateInDto, StockItem>();
        CreateMap<StockItemUpdateInDto, StockItem>();
        CreateMap<StockItem, StockItemQueryOutDto>();
        CreateMap<StockItem, StockItemGetOutDto>();
        #endregion
    }
}