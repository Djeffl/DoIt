using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Modal_Demo.Components
{
	public class ModalReference
	{
		private readonly RenderFragment modalInstance;
		private readonly ModalService modalService;

		public ModalReference(RenderFragment modalInstance, ModalService modalService)
		{
			this.modalInstance = modalInstance;
			this.modalService = modalService;
		}

		public void Close()
		{
			modalService.Close();
		}

		public Task<ModalResult> Result { get; set; }



	}
}
