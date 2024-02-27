import 'package:flutter/material.dart';

void main() {
  runApp(BlogApp());
}

class BlogApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Food Blog',
      theme: ThemeData(
        useMaterial3: true,
      ),
      home: BlogHomePage(),
    );
  }
}

class BlogHomePage extends StatefulWidget {
  @override
  _BlogHomePageState createState() => _BlogHomePageState();
}

class _BlogHomePageState extends State<BlogHomePage> {
  final List<String> _posts = [
    'Průzkum veganských receptů',
    'Umění pečení chleba',
    'Z farmy na stůl: Čerstvé saláty',
    'Dekadentní dezerty a jak je připravit',
    'Svět koření a bylinek',
    'Udržitelná strava a ekologické vaření',
    'Domácí těstoviny workshop',
    'Radost z vaření se sezónními produkty',
    'Grilování: Techniky a recepty',
    'Kulinářská cesta po Asii',
    'Ovládnutí francouzských dezertů',
    'Mořské pochoutky z pobřeží',
    'Objevování tradiční italské kuchyně',
    'Ultimátní průvodce čokoládou',
    'Výroba řemeslných sýrů doma',
    'Historie pizzy',
    'Vaření dokonalé šálky kávy',
    'Soul food a jeho kulturní význam',
    'Věda fermentovaných potravin',
    'Průvodce rostlinnou stravou'
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Flutter Food Blog'),
      ),
      body: ListView.builder(
        itemCount: _posts.length,
        itemBuilder: (context, index) {
          return ListTile(
            title: Text(_posts[index]),
            onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => BlogPostDetail(postTitle: _posts[index])),
              );
            },
          );
        },
      ),
    );
  }
}

class BlogPostDetail extends StatelessWidget {
  final String postTitle;

  BlogPostDetail({required this.postTitle});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(postTitle),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Text('Detaily o $postTitle...'),
      ),
    );
  }
}
