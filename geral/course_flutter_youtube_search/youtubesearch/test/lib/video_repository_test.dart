import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:youtubesearch/lib/http_video_repository.dart';
import 'package:youtubesearch/lib/video_repository.dart';
import 'package:youtubesearch/models/video.dart';

class MockClient extends Mock implements http.Client {}

void main() {
  group('Video repository', () {
    group('find should', () {
      test('return a list of videos with five videos', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search?'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        final List<Video> videos = await videoRepository.find('jovem nerd');

        expect(5, videos.length);
        expect('4qcf7dcNL7w', videos[0].id);
        expect(
          '&quot;Relaxando&quot; na CCXP! (Esse é o Jovem Nerd 😈)',
          videos[0].title,
        );
        expect(
          'https://i.ytimg.com/vi/4qcf7dcNL7w/hqdefault.jpg',
          videos[0].thumbnail,
        );
        expect(
          'Lambda, lambda, lambda, nerds! Hoje, Alexandre Ottoni, o Jovem Nerd, e Deive Pazos, o Azaghal, visitam a CCXP 2019 e dão uma relaxada, mas não ...',
          videos[0].description,
        );
      });
    });

    group('next should', () {
      test('equal to "CAUQAA"', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search?'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        await videoRepository.find('jovem nerd');

        final String next = await videoRepository.next();

        expect(next, 'CAUQAA');
      });
    });

    group('previous should', () {
      test('equal to "CAUQAQ"', () async {
        final String searchList =
            await File('test/fixtures/search_list.json').readAsString();
        final String nextSearchList =
            await File('test/fixtures/next_search_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search?'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              searchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        await videoRepository.find('jovem nerd');

        final String page = await videoRepository.next();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/search?'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              nextSearchList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        await videoRepository.find('jovem nerd', page: page);

        final String previous = await videoRepository.previous();

        expect(previous, 'CAUQAQ');
      });
    });

    group('findOne should', () {
      test('return a video', () async {
        final String videoList =
            await File('test/fixtures/video_list.json').readAsString();

        final MockClient client = MockClient();

        when(client.get(
          argThat(
            startsWith('https://www.googleapis.com/youtube/v3/videos?'),
          ),
        )).thenAnswer(
          (_) => Future.value(
            http.Response(
              videoList,
              200,
              headers: {'content-type': 'application/json; charset=utf-8'},
            ),
          ),
        );

        final VideoRepository videoRepository = HttpVideoRepository(client);

        final Video video = await videoRepository.findOne('video id');

        expect('xONMtd4C1Xk', video.id);
        expect(
          'como NÃO ser assaltado! - LIFEHACKS INCRÍVEIS que vão salvar sua vida (ou não)',
          video.title,
        );
        expect(
          'https://i.ytimg.com/vi/xONMtd4C1Xk/hqdefault.jpg',
          video.thumbnail,
        );
        expect(
          'Leon e Nilce reagem a alguns lifehacks. No vídeo de hoje você vai descobrir:\ncomo não ser assaltado!\ncomo evitar sujeira!\ncomo dar remédio pro filho! \ncomo abrir janela de carros (para fins que não sejam maléficos!)\n\nInscreva-se! Vai ter bolo!\r\nCoisa de Nerd: https://www.youtube.com/user/coisadenerd\r\nCadê a Chave: https://www.youtube.com/cadeachave\r\nNosso grupo no FB: https://www.facebook.com/groups/1084252381760423',
          video.description,
        );
      });
    });
  });
}
