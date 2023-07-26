using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Plugin.Payments.CashOnDelivery.Models;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Services.Configuration;

namespace Nop.Plugin.Payments.CashOnDelivery.Components
{
    public class CashOnDeliveryViewComponent : NopViewComponent
    {
        protected readonly CashOnDeliveryPaymentSettings _cashOnDeliveryPaymentSettings;
        protected readonly ILocalizationService _localizationService;
        protected readonly IStoreContext _storeContext;
        protected readonly IWorkContext _workContext;
        protected readonly ISettingService _settingService;

        public CashOnDeliveryViewComponent(CashOnDeliveryPaymentSettings cashOnDeliveryPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext,
            ISettingService settingService)
        {
            _cashOnDeliveryPaymentSettings = cashOnDeliveryPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
            _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var cashOnDeliverySetting = await _settingService.LoadSettingAsync<CashOnDeliveryPaymentSettings>();
            var model = new PaymentInfoModel
            {
                DescriptionText = cashOnDeliverySetting.DescriptionText,
            };
            return View(model);
        }

    }
}