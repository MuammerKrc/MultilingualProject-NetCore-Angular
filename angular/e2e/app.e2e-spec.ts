import { MultilingualProjectTemplatePage } from './app.po';

describe('MultilingualProject App', function() {
  let page: MultilingualProjectTemplatePage;

  beforeEach(() => {
    page = new MultilingualProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
