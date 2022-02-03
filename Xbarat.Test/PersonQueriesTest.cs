using Application.Persons.Queries;
using Application.Interface.Contexts;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using MediatR;

namespace Xbarat.Test
{
    public class PersonQueriesTest
    {
        [Fact]
        public void GetPersonQuery_Test()
        {
            //Arrange
            var getPersonRequest = new GetPersonRequest();
            var mockUnitOfWork = new Mock<IDataBaseContext>();
            var mockHandler = new Mock<IRequestHandler<GetPersonRequest, List<GetPersonDto>>>();
            
            //Act
            var result = mockHandler.Object.Handle(getPersonRequest, System.Threading.CancellationToken.None);

            //Assert
            Assert.IsType<Task<List<GetPersonDto>>>(result);


        }

        [Theory]
        [InlineData(1,-1)]
        public void GetPersonByIdQuery_Test(long ValidId, long InvalidId)
        {
            #region --------------- Test Valid Id ---------------

                //Arrange
                var getPersonByIdRequest = new GetPersonByIdRequest
                {
                    Id = ValidId
                };
                var mockUnitOfWork = new Mock<IDataBaseContext>();
                var mockHandler = new Mock<IRequestHandler<GetPersonByIdRequest, GetPersonByIdDto>>();

                //Act
                var result = mockHandler.Object.Handle(getPersonByIdRequest, System.Threading.CancellationToken.None);

                //Assert
                Assert.IsType<Task<GetPersonByIdDto>>(result);
                Assert.Equal(result.Result.Id, getPersonByIdRequest.Id);

            #endregion

            #region --------------- Test Invalid Id ---------------

                //Arrange
                getPersonByIdRequest.Id = InvalidId;

                //Act
                result = mockHandler.Object.Handle(getPersonByIdRequest, System.Threading.CancellationToken.None);

                //Assert
                Assert.IsType<Task<GetPersonByIdDto>>(result);
                Assert.Null(result.Result);

            #endregion
        }
    }
}
