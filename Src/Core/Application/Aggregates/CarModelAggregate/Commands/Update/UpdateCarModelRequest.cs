using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aggregates.CarModelAggregate.Commands.Update
{
    public class UpdateCarModelRequest
    {

        public UpdateCarModelRequest(int id, string name, string carPhoto, int carPhotoLenght, int seatNumber, int carBrandId)
        {
            Id = id;
            Name = name;
            CarPhoto = carPhoto;
            CarPhotoLenght = carPhotoLenght;
            SeatNumber = seatNumber;
            CarBrandId = carBrandId;
        }


        public int Id { get; set; }

        [Required]
        public string Name { get; }
        public string? CarPhoto { get; set; }
        public int CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }
        public int CarBrandId { get; set; }

    }
}
