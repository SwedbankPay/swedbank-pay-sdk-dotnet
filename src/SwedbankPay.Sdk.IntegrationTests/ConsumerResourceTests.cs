﻿using SwedbankPay.Sdk.Tests;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.IntegrationTests
{
    public class ConsumerResourceTests: ResourceTestsBase
    {
        private readonly ConsumersRequestContainerBuilder consumerResourceRequestContainer = new ConsumersRequestContainerBuilder();

        [Fact]
        public async Task InitializeConsumer_ReturnsNonEmptyOperationsCollection()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();

            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);

            //ASSERT
            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Operations);
            Assert.NotEmpty(consumer.Operations);
        }

        [Fact]
        public async Task InitializeConsumer_ShouldReturn_NonEmptyToken()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Token);
            Assert.NotEqual(string.Empty, consumer.Token);
        }


        [Fact]
        public async Task InitializeConsumer_ShouldReturn_TokenNotNull()
        {
            //ARRANGE
            var orderResoureRequest = this.consumerResourceRequestContainer.WithTestValues()
                .Build();
            //ACT
            var consumer = await this.Sut.Consumers.InitiateSession(orderResoureRequest);
            //ASSERT

            Assert.NotNull(consumer);
            Assert.NotNull(consumer.Token);
        }
    }
}
