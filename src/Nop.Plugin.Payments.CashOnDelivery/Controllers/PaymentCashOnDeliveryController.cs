using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.CashOnDelivery.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Payments.CashOnDelivery.Controllers
    {
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [AutoValidateAntiforgeryToken]
        public class PaymentCashOnDeliveryController : BasePaymentController
        {
            protected readonly ILanguageService _languageService;
            protected readonly ILocalizationService _localizationService;
            protected readonly INotificationService _notificationService;
            protected readonly IPermissionService _permissionService;
            protected readonly ISettingService _settingService;
            protected readonly IStoreContext _storeContext;

            public PaymentCashOnDeliveryController(ILanguageService languageService,
                ILocalizationService localizationService,
                INotificationService notificationService,
                IPermissionService permissionService,
                ISettingService settingService,
                IStoreContext storeContext)
            {
                _languageService = languageService;
                _localizationService = localizationService;
                _notificationService = notificationService;
                _permissionService = permissionService;
                _settingService = settingService;
                _storeContext = storeContext;
            }

            public async Task<IActionResult> Configure()
            {
                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                    return AccessDeniedView();

                var cashOnDeliveryPaymentSettings = await _settingService.LoadSettingAsync<CashOnDeliveryPaymentSettings>();

                var model = new CODModel
                {
                    DescriptionText = cashOnDeliveryPaymentSettings.DescriptionText,
                    AdditionalFee = cashOnDeliveryPaymentSettings.AdditionalFee,
                    AdditionalFeePercentage = cashOnDeliveryPaymentSettings.AdditionalFeePercentage,
                    ShippableProductRequired = cashOnDeliveryPaymentSettings.ShippableProductRequired
        };
                return View("~/Plugins/Payments.CashOnDelivery/Views/Configure.cshtml", model);
            }

            [HttpPost]
            public async Task<IActionResult> Configure(CODModel model)
            {
                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                    return AccessDeniedView();

                if (!ModelState.IsValid)
                    return await Configure();

                var cashOnDeliveryPaymentSettings = await _settingService.LoadSettingAsync<CashOnDeliveryPaymentSettings>();

                //save settings
                cashOnDeliveryPaymentSettings.DescriptionText = model.DescriptionText;
                cashOnDeliveryPaymentSettings.AdditionalFee = model.AdditionalFee;
                cashOnDeliveryPaymentSettings.AdditionalFeePercentage = model.AdditionalFeePercentage;
                cashOnDeliveryPaymentSettings.ShippableProductRequired = model.ShippableProductRequired;

                await _settingService.SaveSettingAsync(cashOnDeliveryPaymentSettings);

                await _settingService.ClearCacheAsync();

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

                return await Configure();
            }
        }
    }