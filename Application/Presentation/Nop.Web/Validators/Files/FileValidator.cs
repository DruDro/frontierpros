using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Validators.Files
{
	public class FileValidator
	{
		public static int MAX_ICON_SIZE_BYTES = 10000000;//10MB
		public static int MAX_MEDIA_FILE_SIZE_BYTES = 100000000;//100MB

		public static bool ValidateIcon(IFormFile file, ref string errorMessage)
		{
			if (file == null || file.Length == 0)
			{
				errorMessage = "File not selected";
				return false;
			}

			var fileName = file.FileName.ToLowerInvariant();
			if (!fileName.EndsWith(".png") && !fileName.EndsWith(".jpg"))
			{
				errorMessage = "Unsupported file type";
				return false;
			}

			if (file.Length > MAX_ICON_SIZE_BYTES)
			{
				errorMessage = "Image is too large";
				return false;
			}

			return true;
		}
		public static bool ValidateMediaFile(IFormFile file, ref string errorMessage)
		{
			if (file == null || file.Length == 0)
			{
				errorMessage = "File not selected";
				return false;
			}

			var fileName = file.FileName.ToLowerInvariant();
			if (!fileName.EndsWith(".png") && !fileName.EndsWith(".jpg")
				&& !fileName.EndsWith(".mp4") && !fileName.EndsWith(".webm"))
			{
				errorMessage = "Unsupported file type";
				return false;
			}

			if (file.Length > MAX_ICON_SIZE_BYTES 
				&& (fileName.EndsWith(".png") || fileName.EndsWith(".jpg")))
			{
				errorMessage = "Image is too large";
				return false;
			}

			if (file.Length > MAX_MEDIA_FILE_SIZE_BYTES 
				&& (fileName.EndsWith(".mp4") || fileName.EndsWith(".webm")))
			{
				errorMessage = "Video is too large";
				return false;
			}

			return true;
		}
	}
}
