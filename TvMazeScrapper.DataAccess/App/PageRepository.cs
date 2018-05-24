﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Domain.App;
using TvMazeScrapper.Domain.TvMaze;
using TvMazeScrapper.Infrastructure.Interfaces.App;
using TvMazeScrapper.Infrastructure.Interfaces.DataServices;
using TvMazeScrapper.Models.App;

namespace TvMazeScrapper.DataAccess
{
    public class PageRepository : IPageRepository
    {
        private readonly ShowsContext _dbContext;
        private readonly IMapper _mapper;

        public PageRepository(ShowsContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PageModel> TryGetPageAsync(int pageNumber)
        {
            return _mapper.Map<PageModel>(await _dbContext.Pages.FirstOrDefaultAsync(x => x.Id == pageNumber));
        }

        public async Task SavePageAsync(PageModel pageModel)
        {
            await _dbContext.Pages.AddAsync(_mapper.Map<Page>(pageModel));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PageModel> TryGetTvMazePageAsync(int pageNumber)
        {
            return _mapper.Map<PageModel>(await _dbContext.TvMazePages.FirstOrDefaultAsync(x => x.Id == pageNumber));
        }

        public async Task SaveTvMazePageAsync(PageModel pageModel)
        {
            await _dbContext.TvMazePages.AddAsync(_mapper.Map<TvMazePage>(pageModel));
            await _dbContext.SaveChangesAsync();
        }
    }
}