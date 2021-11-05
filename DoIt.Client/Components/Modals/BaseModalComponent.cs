﻿using Microsoft.AspNetCore.Components;

using DoIt.Client.Services.Modals;

namespace DoIt.Client.Components.Modals
{
	public class BaseModalComponent<ParameterT> : BaseModalComponent
	{
		[Parameter]
		public ParameterT Parameter { get; set; }
	}

	public class BaseModalComponent : ComponentBase
	{
		[Inject]
		private ModalService _modalService { get; set; }

		public void CloseModal()
		{
			_modalService.Close();
		}

		public void CloseModal(object response)
		{
			_modalService.Close(response);
		}
	}
}