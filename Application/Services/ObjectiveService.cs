using Domain.Entities;
using Domain.Interfaces.Repositorys;
using Domain.Interfaces.Services;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;


namespace Application.Services
{

    public class ObjectiveService : IObjectiveService
    {
        private readonly IObjectiveRepostory _objectiveRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IConfiguration _configuration;


        public ObjectiveService(IObjectiveRepostory objectiveRepository,ITaskRepository taskRepository,IConfiguration configuration)
        {
            _objectiveRepository = objectiveRepository;
            _taskRepository = taskRepository;
            _configuration = configuration; 
        }


        public async Task<ObjectEntity> Add(ObjectEntity entity)
        {
            var openAiKey = _configuration["OpenAI:ApiKey"];

            var passos =  await GerarPassosParaObjetivoAsync(entity.Description, openAiKey);
            var obj= await _objectiveRepository.Add(entity);
            var list = new List<TaskEntity>();
            foreach(var passo in passos)
            {
                var task = new TaskEntity {
                    Id = 0,
                    ObjectiveId = obj.Id,
                Name=passo,
                IsCompleted=false,
                Created_At=DateTime.Now,
                Updated_At=DateTime.Now     
                };
                await _taskRepository.Add(task);
                list.Add(task);
                
            }

            return obj;
        }


        public async Task<ObjectEntity> Delete(ObjectEntity entity)
        {
            return await _objectiveRepository.Delete(entity);
        }


        public async Task<List<ObjectEntity>> GetAll()
        {
            return await _objectiveRepository.GetAll();
        }


        public async Task<ObjectEntity> GetById(int id)
        {
            return await _objectiveRepository.GetById(id);
        }


        public async Task<ObjectEntity> Update(ObjectEntity entity)
        {
            return await _objectiveRepository.Update(entity);
        }


        public async Task<List<ObjectEntity>> GetAllObjectEntities(int? userId)
        {
           
            if (userId.HasValue)
            {
                return await _objectiveRepository.GetAllObjectEntities(userId.Value);
            }
            else
            {
                return await _objectiveRepository.GetAll(); 
            }
        }




        public async Task<List<string>> GerarPassosParaObjetivoAsync(string objetivo, string openAiKey)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiKey);

        var prompt = $"Responda apenas com um array JSON de strings com 10 passos para executar esse objetivo: {objetivo}. Não adicione explicações, apenas o array.";

        var body = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
            new { role = "user", content = prompt }
        }
        };

        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

           var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
           response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(responseString);
        string rawContent = json.choices[0].message.content.ToString();

        rawContent = rawContent.Replace("json", "");
        string jsonArrayString;
        if (rawContent.Contains("```"))
        {
            var partes = rawContent.Split("```");


            jsonArrayString = partes.FirstOrDefault(p => p.TrimStart().StartsWith("["));
        }
        else
        {
            jsonArrayString = rawContent;
        }

        var passos = JsonConvert.DeserializeObject<List<string>>(jsonArrayString);

        return passos;
    }
}
}
