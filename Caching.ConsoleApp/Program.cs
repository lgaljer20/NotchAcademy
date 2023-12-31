﻿using Microsoft.Extensions.Caching.Memory;
using System;
using Caching.Business.Entities;
using Caching.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Caching.Business.Services;
using Kafka;
using System.Collections.Generic;

namespace Caching
{
    class program
    {

        static void Main(string[] args)
        {

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<ICachingService, CachingService>();
            services.AddScoped<DataContext>();

            var kafkaService = new KafkaConsumerService("34.159.95.180:9092", "cassiopeia", "cassiopeia-dev1");
            services.AddSingleton<KafkaConsumerService>(kafkaService);

            var serviceProvider = services.BuildServiceProvider();

            ICachingService cachingService = serviceProvider.GetRequiredService<ICachingService>();
            KafkaConsumerService kafkaConsumerService = serviceProvider.GetRequiredService<KafkaConsumerService>();

            Console.WriteLine("First run:");
            List<SatelliteInfo> satellites = cachingService.GetAll().ToList();

            foreach (CacheEntryExtensions satellite in satellites)
            {
                Console.WriteLine(satellite.Name);
            }

            Console.WriteLine("Second run:");
            List<SatelliteInfo> sortedCaches = cachingService.GetAll().OrderBy(x => x.id).ToList();

            foreach (CacheEntryExtensions satellite in sortedCaches)
            {
                Console.WriteLine(satellite.Name);
            }

            kafkaConsumerService.ConsumeMessages();

            kafkaConsumerService.Dispose();

            //var cache = new MemoryCache(new MemoryCacheOptions());

            //string cacheKey = "myCachedItem";

            //var cachedItem = cache.GetOrCreate(cacheKey, entry =>
            //{
            //    entry.SlidingExpiration = TimeSpan.FromSeconds(10);
            //    return "my cached item";
            //});

            //var cacheEntryOptions = new MemoryCacheEntryOptions()
            //    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            //cache.Set(cacheKey, cachedItem, cacheEntryOptions);

            //var value = cache.Get<string>(cacheKey);
            //Console.WriteLine(value);


        }
    }
}