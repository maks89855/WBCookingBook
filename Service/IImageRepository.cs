﻿namespace WebCookingBook.API.Service
{
    public interface IImageRepository
    {
        public Task<string> Upload(IFormFile file, string path);
		public Task<string> Upload(IFormFile file);
	}
}