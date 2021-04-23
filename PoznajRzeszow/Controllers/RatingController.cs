﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajRzeszow.Application.Commands.Ratings.CreateRating;
using PoznajRzeszow.Application.Commands.Ratings.DeleteRating;
using PoznajRzeszow.Application.Commands.Ratings.UpdateRating;
using PoznajRzeszow.Application.Queries.Ratings.GetRatings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajRzeszow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRating([FromForm] CreateRatingCommand command)
            => Ok(await _mediator.Send(command));

        [HttpDelete("{ratingId}")]
        [Authorize]
        public async Task<IActionResult> DeleteRating([FromRoute] Guid ratingId)
            => Ok(await _mediator.Send(new DeleteRatingCommand
            {
                RatingId = ratingId
            }));

        [HttpGet("getRatings/{placeId}")]
        public async Task<IActionResult> GetRatings([FromRoute] Guid placeId)
            => Ok(await _mediator.Send(new GetRatingsQuery
            {
                PlaceId = placeId
            }));

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateRating([FromBody] UpdateRatingCommand command)
            => Ok(await _mediator.Send(command));
    }
}
