using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
    {
    public class AnimeDto
        {
        public List<SourcesDto> Sources { get; set; } = new List<SourcesDto>();
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Episodes { get; set; }
        public string Status { get; set; }
        public SeasonsDto AnimeSeason { get; set; } = new SeasonsDto();
        public string Picture { get; set; }
        public string ThumbNail { get; set; }
        public List<SynonymsDto> Synonyms { get; set; } = new List<SynonymsDto>();
        public List<RelationsDto> Relations { get; set; } = new List<RelationsDto>();
        public List<TagsDto> Tags { get; set; } = new List<TagsDto>();

        }
    }
