using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegionAPI;
using RegionAPI.Models;
using RegionAPI.Repositories;
using RegionAPI.ViewModels;

namespace RegionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IRepository<CountryModel> _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(IRepository<CountryModel> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("", Name = "GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_countryRepository.GetAll().Select(x =>
                {
                       return _mapper.Map<CountryViewModel>(x);
                }));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

       

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingle")]
        public IActionResult Get(int id)
        {
            try
            {
                CountryModel countryModel = _countryRepository.GetSingle(id);

                if (countryModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CountryViewModel>(countryModel));
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

       
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CountryViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CountryModel singleById = _countryRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                singleById.Name = viewModel.Name;

                _countryRepository.Update(singleById);
                int save = _countryRepository.Save();

                if (save > 0)
                {
                    return Ok(_mapper.Map<CountryViewModel>(singleById));
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


       
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CountryViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CountryModel item = _mapper.Map<CountryModel>(viewModel);

                _countryRepository.Add(item);
                int save = _countryRepository.Save();

                if (save > 0)
                {
                    return CreatedAtRoute("GetSingle", new { controller = "CountryModels", id = item.Id }, item);
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

       

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CountryModel singleById = _countryRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                _countryRepository.Delete(singleById);
                int save = _countryRepository.Save();

                if (save > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    

}
}
